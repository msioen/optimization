﻿using System;
using System.Collections.Generic;
using System.Linq;
using Itinero.Optimization.Models.Vehicles;

namespace Itinero.Optimization.Tests.Functional.CVRP
{
    public static class CVRPTests
    {
        /// <summary>
        /// Runs some functional tests related to the CVRP.
        /// </summary>
        public static void Run()
        {
            Run1Wechelderzande();
        }

        public static void Run1Wechelderzande()
        {
            // WECHELDERZANDE - LILLE
            // build routerdb and save the result.
            var lille = Staging.RouterDbBuilder.Build("query3");
            var vehicle = lille.GetSupportedVehicle("car");
            var router = new Router(lille);

            // build problem1.
            var locations = Staging.StagingHelpers.GetLocations(
                Staging.StagingHelpers.GetFeatureCollection("CVRP.data.problem1.geojson"));
            
            // build vehicle pool.
            var vehicles = VehiclePool.FromProfile(vehicle.Fastest(), 0, 0, 1000, true);
            
            // run
            Func<Action<IEnumerable<Result<Route>>>, IEnumerable<Result<Route>>> func = (intermediateRoutesFunc) =>
                router.Optimize(vehicles, locations, out _, intermediateRoutesFunc);
            func.RunWithIntermedidates("CVRP-" + "lille");

//            WriteStats(routes);
//            routes.WriteGeoJson(DepotCVRPTests.Name + "lille-{0}.geojson");
        }
    }
}