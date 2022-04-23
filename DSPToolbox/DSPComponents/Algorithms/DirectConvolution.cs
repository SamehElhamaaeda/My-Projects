using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            List<float> Samples = new List<float>();
            List<float> SignalFrequencies = new List<float>();
            List<float> FrequenciesAmplitudes = new List<float>();
            List<float> FrequenciesPhaseShifts = new List<float>();
            bool Periodic = false;
            OutputConvolvedSignal = new Signal(Samples, Periodic, SignalFrequencies, FrequenciesAmplitudes, FrequenciesPhaseShifts);

            int outputLength = InputSignal1.Samples.Count + InputSignal2.Samples.Count;
            int minIndex = InputSignal1.SamplesIndices[0] + InputSignal2.SamplesIndices[0];

            float signal1k, signal2nMk, output;

            for (int i = 0; i <= outputLength; i++)
            {
                output = 0;
                for (int j = 0; j <= i; j++)
                {
                    if (j < InputSignal1.Samples.Count)
                        signal1k = InputSignal1.Samples[j];
                    else
                        break;
                    if (i - j < InputSignal2.Samples.Count)
                        signal2nMk = InputSignal2.Samples[i - j];
                    else
                        signal2nMk = 0;
                    output += signal1k * signal2nMk;
                }
                OutputConvolvedSignal.Samples.Add(output);
                OutputConvolvedSignal.SamplesIndices.Add(minIndex++);
            }

            while (OutputConvolvedSignal.Samples[OutputConvolvedSignal.Samples.Count - 1] == 0)
            {
                OutputConvolvedSignal.Samples.RemoveAt(OutputConvolvedSignal.Samples.Count - 1);
                OutputConvolvedSignal.SamplesIndices.RemoveAt(OutputConvolvedSignal.SamplesIndices.Count - 1);
            }

            while (OutputConvolvedSignal.Samples[0] == 0)
            {
                OutputConvolvedSignal.Samples.RemoveAt(0);
                OutputConvolvedSignal.SamplesIndices.RemoveAt(0);
            }
        }
    }
}
