﻿/*
 *  Licensed to SharpSoftware under one or more contributor
 *  license agreements. See the NOTICE file distributed with this work for 
 *  additional information regarding copyright ownership.
 * 
 *  SharpSoftware licenses this file to you under the Apache License, 
 *  Version 2.0 (the "License"); you may not use this file except in 
 *  compliance with the License. You may obtain a copy of the License at
 * 
 *       http://www.apache.org/licenses/LICENSE-2.0
 * 
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using System;
using Itinero.Optimization.Solvers.Tours;
using Itinero.Optimization.Solvers.TSP_TW;
using Xunit;

namespace Itinero.Optimization.Tests.Solvers.TSP_TW
{
    public class TSPTWFitnessTests
    {
        [Fact]
        public void TSPTWFitness_ShouldTakeIntoAccountTripToFirst()
        {
            // create problem.
            var problem = new TSPTWProblem(0, 0, WeightMatrixHelpers.Build(5, 10),
                TimeWindowHelpers.Unlimited(5));
            var tour = new Tour(new[] {0, 1, 2, 3, 4}, 0);
            
            Assert.Equal(50, tour.Fitness(problem));
        }
    }
}