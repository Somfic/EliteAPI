using System;

// Test the calculation for "Byaa Eurk NJ-L b52-0 A 6"
// From journal: Sudarsky class I gas giant, MassEM=33.010155, WasDiscovered=false

double massEM = 33.010155;
long baseValue = 1656; // Sudarsky Class I base value
bool wasDiscovered = false;

var scanValue = (float)baseValue;
var massFactor = (float)Math.Max(massEM, 1.0);

// Elite Dangerous formula: baseValue * (1 + mass^0.2 * 0.56591828)
var bodyValue = Math.Max(
    scanValue + scanValue * (float)Math.Pow(massFactor, 0.2) * 0.56591828f,
    500f
);

// FSS value: 2.6x for first discovery
float fssMultiplier = wasDiscovered ? 1.0f : 2.6f;
long fssValue = (long)(bodyValue * fssMultiplier);

// DSS value: 9.619019x for first discovery + first map
float dssMultiplier = 9.619019f;
long dssValue = (long)(bodyValue * dssMultiplier);

Console.WriteLine($"Body value (base): {bodyValue}");
Console.WriteLine($"FSS value: {fssValue:N0}");
Console.WriteLine($"DSS value: {dssValue:N0}");
