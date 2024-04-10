using CLIENT.Models.ViewModels;
using CLIENT.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CLIENT.Controllers
{
    public class TarjetaController : Controller
    {
        private readonly IServiceTarjeta _serviceTarjeta;
        private readonly IServiceMovimientosTarjeta _serviceMovimientos;

        public TarjetaController(IServiceTarjeta serviceTarjeta, IServiceMovimientosTarjeta serviceMovimientos)
        {
            _serviceTarjeta = serviceTarjeta;
            _serviceMovimientos = serviceMovimientos;
        }


        [HttpGet]
        public async Task<IActionResult> Detalles(int id, string numeroTarjeta)
        {
            TarjetaCreditoVM tarjeta = await _serviceTarjeta.getTarjetaInfo(id, numeroTarjeta);
            return View(tarjeta);
        }

        [HttpGet]
        public async Task<IActionResult> ImprimirEstadoCuenta(int id, string numeroTarjeta, int mes, int anio)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            TarjetaCreditoVM tarjeta = await _serviceTarjeta.getTarjetaInfo(id, numeroTarjeta);
            List<MovimientosTarjetaVM> movimientos = await _serviceMovimientos.ObtenerMovimientosTarjeta(id, numeroTarjeta, 3, mes, anio);
            // Ordenar los movimientos por fecha de forma descendente (la más reciente primero)
            movimientos = movimientos.OrderByDescending(m => m.fechaMovimiento).ToList();
            var Data = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.Letter.Portrait());
                    page.Margin(30);
                    //page.Header().Height(100).Background(Colors.Blue.Medium);
                    //page.Content().Background(Colors.Yellow.Medium);
                    //page.Footer().Height(50).Background(Colors.Red.Medium);
                    ///Relative y constant establecemos el ancho del item
                    ///Header
                    page.Header().ShowOnce().Row(row =>
                    {

                        row.RelativeItem().Column(col =>
                        {
                            col.Item().AlignCenter().Text("Banco Atlántida").Bold().FontSize(16).FontColor("#D9272E");
                            col.Item().AlignCenter().Text("Dirección xxxxx, San Salvador").FontSize(9);
                            col.Item().AlignCenter().Text("Tel: 2223-7676").FontSize(9);
                            col.Item().AlignCenter().Text("www.bancoatlantida.com.sv").FontSize(9);
                        });

                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Border(1).BorderColor("#D9272E").AlignCenter().Padding(5).Text("San Salvador " + DateTime.Now.ToLongDateString()).FontSize(8);
                            col.Item().Border(1).BorderColor("#D9272E").Background("#D9272E").Padding(5).AlignCenter().Text("ESTADO DE CUENTA").FontColor("#fff").FontSize(10);
                            col.Item().Border(1).BorderColor("#D9272E").Padding(5).AlignCenter()
                            .Text(System.DateTime.Now.ToLongDateString()).FontSize(8);
                        });
                    });
                    ///El contenido del reporte
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {

                        col1.Item().Row(row1 =>
                        {
                            row1.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Nombre titular").Bold();

                                col.Item().Text(txt =>
                                {
                                    txt.Span(tarjeta.nombreTitular).FontSize(10);
                                });

                                col.Item().Text("Número de tarjeta").Bold();

                                col.Item().Text(txt =>
                                {
                                    txt.Span($"{tarjeta.numeroTarjeta}").FontSize(10);
                                });
                            });

                            row1.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Detalles").Bold();

                                col.Item().Text(txt =>
                                {
                                    txt.Span($"Saldo actual: {tarjeta.saldoTotal.ToString("C")}").FontSize(10);
                                });
                                col.Item().Text(txt =>
                                {
                                    txt.Span($"Saldo disponible: {tarjeta.disponible.ToString("C")}").FontSize(10);
                                });
                                col.Item().Text(txt =>
                                {
                                    txt.Span($"Límite de crédito: {tarjeta.montoOtorgado.ToString("C")}").FontSize(10);
                                });
                                col.Item().Text(txt =>
                                {
                                    txt.Span($"Cuota mínima: {tarjeta.cuotaMinima.ToString("C")}").FontSize(10);
                                });
                                col.Item().Text(txt =>
                                {
                                    txt.Span($"Interés bonificable: {tarjeta.interesBonificable.ToString("C")}").FontSize(10);
                                });
                                col.Item().Text(txt =>
                                {
                                    txt.Span($"Monto total con interés: {tarjeta.totalContadoConInteres.ToString("C")}").FontSize(10);
                                });
                            });
                        });


                        col1.Item().PaddingTop(10).Column(col3 =>
                        {
                            col3.Item().Text("Estimado(a)(os) Sr(a)(es):").Bold();

                            col3.Item().PaddingTop(5).Text(txt =>
                            {
                                txt.Span($"Adjuntamos el estado de cuenta con fecha de corte {System.DateTime.Now.ToLongDateString()} en el cual se detallan sus compras y pagos de su tarjeta de crédito").FontSize(10);
                            });
                        });

                        ///Linea de separación
                        ///

                        col1.Item().LineHorizontal(0.5f);

                        ///Tabla de datos
                        ///

                        col1.Item().Table(tabla =>
                        {
                            ///Definicion de las columnas
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                            });

                            tabla.Header(header =>
                            {
                                header.Cell().Background("#D9272E").Padding(3)
                                .Text("Fecha").FontColor("#fff").FontSize(10);
                                header.Cell().Background("#D9272E").Padding(3)
                               .Text("Descripción").FontColor("#fff").FontSize(10); ;
                                header.Cell().Background("#D9272E").Padding(3)
                               .Text("Monto").FontColor("#fff").FontSize(10); ;
                            });

                            ///Llenar la informacion de la tabla
                            ///
                            foreach (var movimiento in movimientos)
                            {

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(3).Text(movimiento.fechaMovimiento.ToLongDateString()).FontSize(8);


                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(3).Text(movimiento.descripcion).FontSize(8);


                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(3).Text(movimiento.monto.ToString("C")).FontSize(8);


                            }

                        });

                        col1.Item().AlignRight().Text($"Total en movimientos: {movimientos.Sum(x=> x.monto).ToString("C")}").FontSize(10);

                        ///Validaciones para mostrar informacion
                        //if (1 == 1)
                        //{
                        //    col1.Item().Background(Colors.Grey.Lighten3).Padding(10)
                        //    .Column(column =>
                        //    {
                        //        column.Item().Text("Comentarios").FontSize(14);
                        //        column.Item().Text(Placeholders.LoremIpsum()).FontSize(10);
                        //        column.Spacing(5);

                        //    });
                        //}
                        col1.Item().PaddingTop(15).Column(col3 =>
                        {
                            col3.Item().Text(text =>
                            {
                                text.Span("Recuerde realizar sus pagos a tiempo para evitar intereses y moras en su saldo").FontSize(10);
                            });
                            col3.Item().PaddingTop(10).Text(text =>
                            {
                                text.Span("Ejecutivo de Cuenta: César Guerrero").FontSize(10);
                            });
                        });

                        col1.Item().AlignRight().Text("Elaborado por César Guerrero").FontSize(10);




                        col1.Spacing(10);

                    });
                    ///El footer del reporte
                    ///
                    page.Footer().
                    AlignRight().Text(txt =>
                    {
                        txt.Span("Página ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" de ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });

                });
            }).GeneratePdf();
            Stream stream = new MemoryStream(Data);
            return File(stream, "application/pdf", $"{numeroTarjeta}_Estado_Cuenta{DateTime.Now.ToShortDateString()}.pdf");

        }


    }
}
