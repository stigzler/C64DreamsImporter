using stigzler.Utilities.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C64DreamsImporter.DTOs
{
    internal class MainLibraryImportResults
    {
        public string OperationSummary {  get; set; }
        public List<MoveCopyException> MoveCopyExceptions {  get; set; } = new List<MoveCopyException> { }; 
    }
}
