using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManyConsole;
using Thought.vCards;

namespace VcfReader
{
    public class VcfToCsvCommand : ConsoleCommand
    {
        public VcfToCsvCommand()
        {
            this.IsCommand("vcf2csv", "Converts a VCF file to CSV format.");
            this.HasRequiredOption("i=", "Path of VCF file", v => Filepath = v);
        }

        public string Filepath;

        public override int Run(string[] remainingArguments)
        {
            using (var stream = new StreamReader(new FileStream(Filepath, FileMode.Open)))
            {
                while (!stream.EndOfStream)
                {
                    var card = new vCard(stream);
                    var select = new
                    {
                        name = card.FormattedName,
                        phones = string.Join(",", card.Phones.Select(p => p.FullNumber)),
                        email = card.EmailAddresses
                    };
                    
                    if (string.IsNullOrEmpty(select.phones) || string.IsNullOrEmpty(select.name))
                        continue; ;

                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(select));
                }
            }

            return 0;
        }
    }
}
