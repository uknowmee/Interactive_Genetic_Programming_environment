﻿using System;
using Shared;

const string text = """
                    using System;
                    using Shared.Interfaces;
                    
                    namespace CustomFitness;
                    
                    public class FitnessFunction
                    {
                        public static double Evaluate(IEvaluable individual)
                        {
                            var fitness = 0.0;
                    
                            foreach (var testCase in individual.TestCases)
                            {
                                var output = testCase.Output;
                                var predicted = testCase.Predicted;
                    
                                if (output.Count == 0)
                                {
                                    fitness -= 1000;
                                    fitness -= individual.ProgramLength * 5;
                                }
                                else
                                {
                                    fitness -= (output.Count - 1) * 20;
                                    if (fitness > -400000)
                                    {
                                        fitness -= Math.Abs(1 - output[0] / predicted[0]);
                                    }
                                }
                            }
                    
                            return fitness;
                        }
                    }
                    """;

var evaluable = new Individual();
var returned = new FitnessFunction("1_3_B", text).Run([evaluable]);

Console.Out.WriteLine("Returned: " + returned);
Console.Out.WriteLine("Returned: " + CustomFitness.Example.FitnessFunction.Evaluate(evaluable));