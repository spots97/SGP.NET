using SGPdotNET.TLE;
using SGPdotNET.Propagation;
using static System.Console;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Accessed 2022-05-12 @ 17:15
string[] issTle = {
    "ISS (ZARYA)             ",
    "1 25544U 98067A   22132.54238162  .00007330  00000+0  13605-3 0  9991",
    "2 25544  51.6432 153.1122 0006817  89.6534  11.1576 15.50041161339656"
};

Tle tle = new(issTle[0], issTle[1], issTle[2]);
Orbit issOriginalOrbit = new(tle);
Sgp4 sgp4 = new Sgp4(tle);

var date = new DateTime(2022, 05, 12, 23, 13, 00);
var precessedOrbit = sgp4.GetPropagatedOrbitSgp4((date - issOriginalOrbit.Epoch).TotalMinutes);

WriteLine($"Inclination:\t\t{precessedOrbit.Inclination.Degrees} [Original: {issOriginalOrbit.Inclination.Degrees}]");
WriteLine($"RAAN:\t\t\t{precessedOrbit.AscendingNode.Degrees} [Original: {issOriginalOrbit.AscendingNode.Degrees}]");
WriteLine($"Eccentricity:\t\t{precessedOrbit.Eccentricity} [Original: {issOriginalOrbit.Eccentricity}]");
WriteLine($"Arg. of Perigee:\t\t{precessedOrbit.ArgumentPerigee.Degrees} [Original: {issOriginalOrbit.ArgumentPerigee.Degrees}]");
WriteLine($"Mean Anomaly:\t\t{precessedOrbit.MeanAnomoly.Degrees} [Original: {issOriginalOrbit.MeanAnomoly.Degrees}]");