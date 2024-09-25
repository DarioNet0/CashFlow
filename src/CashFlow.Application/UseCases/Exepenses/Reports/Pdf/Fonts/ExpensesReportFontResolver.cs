using MigraDoc.DocumentObjectModel;
using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Exepenses.Reports.Pdf.Fonts
{
    public class ExpensesReportFontResolver : IFontResolver
    {
        public byte[]? GetFont(string faceName)
        {
            var stream = ReadFontFile(faceName);

            if (stream is null)
            {
                stream = ReadFontFile(FontHelper.DEFAULT_FONT);            
            }

            var lenght = (int)stream!.Length;

            var data = new byte[lenght];

            stream.Read(buffer: data, offset: 0, count: lenght);

            return data;
        }

        public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
        {
            var font = new Font
            {
                Name = FontHelper.RALEWAY_REGULAR
            };
            return new FontResolverInfo(familyName);
        }
        private Stream? ReadFontFile(string faceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            return assembly.GetManifestResourceStream($"CashFlow.Application.UseCases.Exepenses.Reports.Pdf.Fonts.{faceName}.ttf");
        }
    }
}
