using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект2
{
    internal class ReportViewModel 
    {
        public List<string> GryzLabels { get; set; }

        public List<int> GryzValues { get; set; }
        public List<double> RelativeFrequencies { get; set; }
        public List<double> AccumulatedRelativeFrequencies { get; set; }
        public Материал BigCargo { get; set; }

        public ReportViewModel()
        {
            List<Материал> ychet_Gryzovs = DataBase1.GetContext().Материал.Where(p => p.Фильтр == 1).ToList();
            GryzLabels = ychet_Gryzovs.Select(p => p.Название).ToList();
            GryzValues = ychet_Gryzovs.Select(p => p.Код_материала).ToList();

            RelativeFrequencies = GryzValues.Select(p => (double)p / GryzValues.Sum()).ToList();
            AccumulatedRelativeFrequencies = new List<double>();
            AccumulatedRelativeFrequencies.Add(RelativeFrequencies[0]);
            for (int i = 1; i < RelativeFrequencies.Count; i++)
            {
                AccumulatedRelativeFrequencies.Add(AccumulatedRelativeFrequencies[i - 1] + RelativeFrequencies[i]);
            }
            BigCargo = ychet_Gryzovs.FirstOrDefault(p => p.Код_материала == GryzValues.Max());
        }

   
    }
}
