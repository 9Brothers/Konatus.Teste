using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using Konatus.Teste.Domain.Interfaces.Repositories.Files;

namespace Konatus.Teste.Infrastructure.Files
{
    public class ExcelRepository<T> : IExcelRepository<T> where T : class
    {
        public MemoryStream Export(IEnumerable<T> entities)
        {
            using (var workbook = new XLWorkbook())
            {
                var entityType = typeof(T);
                var worksheet = workbook.Worksheets.Add(entityType.Name);                
                var properties = entityType.GetProperties();                
                var currentRow = 1;
                var currentCell = 1;

                foreach (var property in properties)
                {
                    worksheet.Cell(currentRow, currentCell).Value = property.Name;
                    
                    currentCell++;
                }

                foreach (var entity in entities)
                {
                    currentRow++;
                    
                    currentCell = 1;

                    foreach (var property in properties)
                    {
                        worksheet.Cell(currentRow, currentCell).Value = entity.GetType().GetProperty(property.Name).GetValue(entity);    

                        currentCell++;
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    
                    return stream;
                }
            }
        }        
    }
}