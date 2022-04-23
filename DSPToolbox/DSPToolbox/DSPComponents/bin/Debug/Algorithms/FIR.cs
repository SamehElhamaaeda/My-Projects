using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class FIR : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public FILTER_TYPES InputFilterType { get; set; }
        public float InputFS { get; set; }
        public float? InputCutOffFrequency { get; set; }
        public float? InputF1 { get; set; }
        public float? InputF2 { get; set; }
        public float InputStopBandAttenuation { get; set; }
        public float InputTransitionBand { get; set; }
        public Signal OutputHn { get; set; }
        public Signal OutputYn { get; set; }

        public override void Run()
        {
            //initializations
            List<float> Samplesh = new List<float>();
            List<float> SignalFrequenciesh = new List<float>();
            List<float> FrequenciesAmplitudesh = new List<float>();
            List<float> FrequenciesPhaseShiftsh = new List<float>();
            bool Periodich = false;
            OutputHn = new Signal(Samplesh, Periodich, SignalFrequenciesh, FrequenciesAmplitudesh, FrequenciesPhaseShiftsh);
            List<float> Samplesy = new List<float>();
            List<float> SignalFrequenciesy = new List<float>();
            List<float> FrequenciesAmplitudesy = new List<float>();
            List<float> FrequenciesPhaseShiftsy = new List<float>();
            bool Periodicy = false;
            OutputYn = new Signal(Samplesy, Periodicy, SignalFrequenciesy, FrequenciesAmplitudesy, FrequenciesPhaseShiftsy);
            
            //get f and normalize it & calculate omega
            double fc = 0, omegaC = 0;
            double f1 = 0, f2 = 0, omegaC1 = 0, omegaC2 = 0;
            if (InputFilterType == FILTER_TYPES.LOW)
            {
                fc = (double)InputCutOffFrequency + (InputTransitionBand / 2);
                fc /= InputFS;
                omegaC = 2 * Math.PI * fc;
            }
            else if (InputFilterType == FILTER_TYPES.HIGH)
            {
                fc = (double)InputCutOffFrequency - (InputTransitionBand / 2);
                fc /= InputFS;
                omegaC = 2 * Math.PI * fc;
            }
            else if (InputFilterType == FILTER_TYPES.BAND_PASS)
            {
                f1 = (double)InputF1 - (InputTransitionBand / 2);
                f2 = (double)InputF2 + (InputTransitionBand / 2);
                f1 /= InputFS;
                f2 /= InputFS;
                omegaC1 = 2 * Math.PI * f1;
                omegaC2 = 2 * Math.PI * f2;

            }
            else
            {
                f1 = (double)InputF1 + (0.5 * InputTransitionBand);
                f2 = (double)InputF2 - (0.5 * InputTransitionBand);
                f2 /= InputFS;
                f1 /= InputFS;
                omegaC1 = 2 * Math.PI * f1;
                omegaC2 = 2 * Math.PI * f2;
            }
            //get n & calculate N & make it odd only
            double n = 0;
            if (InputStopBandAttenuation <= 21)
                n = 0.9;
            else if (InputStopBandAttenuation <= 44)
                n = 3.1;
            else if (InputStopBandAttenuation <= 53)
                n = 3.3;
            else
                n = 5.5;
            int N = (int)Math.Round(n / (InputTransitionBand / InputFS)); 
            if (N % 2 == 0) 
                N++;
            double h = 0, w = 0;
            OutputHn.Samples = Enumerable.Repeat(0f, N).ToList();
            OutputHn.SamplesIndices = Enumerable.Repeat(0, N).ToList();
            for (int i = 0; i <= N / 2; i++)
            {
                if (i == 0)
                {
                    if (InputFilterType == FILTER_TYPES.LOW)
                        h = 2 * fc;
                    else if (InputFilterType == FILTER_TYPES.HIGH)
                        h = 1 - (2 * fc);
                    else if (InputFilterType == FILTER_TYPES.BAND_PASS)
                        h = 2 * (f2 - f1);
                    else
                        h = 1 - (2 * (f2 - f1));
                }
                else
                {
                    if (InputFilterType == FILTER_TYPES.LOW)
                        h = 2 * fc * (Math.Sin(i * omegaC) / (i * omegaC));
                    else if (InputFilterType == FILTER_TYPES.HIGH)
                        h = -2 * fc * (Math.Sin(i * omegaC) / (i * omegaC));
                    else if (InputFilterType == FILTER_TYPES.BAND_PASS)
                        h = 2 * f2 * (Math.Sin(i * omegaC2) / (i * omegaC2)) - 2 * f1 * (Math.Sin(i * omegaC1) / (i * omegaC1));
                    else
                        h = 2 * f1 * (Math.Sin(i * omegaC1) / (i * omegaC1)) - 2 * f2 * (Math.Sin(i * omegaC2) / (i * omegaC2));
                }
                //w = w = .54 + .46 * (Math.Cos(2 * Math.PI * i / N));
                if (InputStopBandAttenuation <= 21)
                    w = 1;
                else if (InputStopBandAttenuation <= 44)
                    w = .5 + .5 * (Math.Cos(2 * Math.PI * i / N));
                else if (InputStopBandAttenuation <= 53)
                    w = .54 + .46 * (Math.Cos(2 * Math.PI * i / N));
                else
                    w = .42 + .5 * (Math.Cos(2 * Math.PI * i / (N - 1))) + .08 * (Math.Cos(4 * Math.PI * i / (N - 1)));
                OutputHn.Samples[N / 2 - i] = (float)(h * w);
                OutputHn.Samples[N / 2 + i] = (float)(h * w);
                OutputHn.SamplesIndices[N / 2 - i] = -i;
                OutputHn.SamplesIndices[N / 2 + i] = i;
            }
            DirectConvolution conv = new DirectConvolution();
            conv.InputSignal1 = InputTimeDomainSignal;
            conv.InputSignal2 = OutputHn;
            conv.Run();

            OutputYn = conv.OutputConvolvedSignal;
        }
    }
}
