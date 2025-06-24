using System;
using System.Collections.Generic;

namespace PTXClassLibrary
{
    public class ChartDataSets
    {
        public List<string> BarChartLabels { get; set; }
        public List<ChartDataset> Datasets { get; set; }
    }

    public class ChartDataset
    {
        public ChartDataset(string label, List<int> data, string backgroundColor, string borderColor, int borderWidth)
        {
            Label = label;
            Data = data;
            BackgroundColor = backgroundColor;
            BorderColor = borderColor;
            BorderWidth = borderWidth;
        }



        public string Label { get; set; }
        public List<int> Data { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public int BorderWidth { get; set; }
    }
}
