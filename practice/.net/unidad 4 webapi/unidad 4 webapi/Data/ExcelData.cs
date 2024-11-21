using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace unidad_4_webapi.Data
{
    public class ExcelData
    {
        public List<string> ObtenerEncabezados(string filePath)
        {
            var encabezados = new List<string>();
            // Abre el archivo Excel en la ruta especificada.
            using (var workbook = new XLWorkbook(filePath))
            {
                // Obtiene la primera hoja del archivo.
                var worksheet = workbook.Worksheet(1);
                // Encuentra la última columna utilizada en la primera fila para determinar encabezados hay.
                int lastColumnUsed = worksheet.LastColumnUsed().ColumnNumber();
                // Recorre las columnas en la primera fila y obtiene el nombre de cada columna.
                for (int col = 1; col <= lastColumnUsed; col++)
                {
                    // Obtiene el valor de la celda como texto.
                    string encabezado = worksheet.Cell(1, col).GetValue<string>();
                    encabezados.Add(encabezado);
                }
            }
            return encabezados;
        }
    }
}
