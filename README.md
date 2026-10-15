# MarcusMedina.Units.Temperature

[![NuGet](https://img.shields.io/nuget/v/MarcusMedina.Units.Temperature.svg?style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/MarcusMedina.Units.Temperature/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MarcusMedina.Units.Temperature.svg?style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/MarcusMedina.Units.Temperature/)
[![C#](https://img.shields.io/badge/C%23-14.0-239120?style=for-the-badge&logo=csharp&logoColor=white)](#)
[![.NET](https://img.shields.io/badge/.NET-10.0+-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)
[![Open Source](https://raw.githubusercontent.com/MarcusMedinaPro/MarcusMedina.Units.Temperature/main/assets/open-source.svg)](https://opensource.org)
[![Build](https://img.shields.io/github/actions/workflow/status/MarcusMedinaPro/MarcusMedina.Units.Temperature/release.yml?branch=main&label=Build&style=for-the-badge&logo=github)](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Temperature/actions)
[![Signed](https://img.shields.io/badge/Signed-Sigstore-green?style=for-the-badge&logo=linux)](https://docs.sigstore.dev)
[![Wiki](https://img.shields.io/badge/docs-wiki-blue?style=for-the-badge&logo=github)](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Temperature/wiki)

**Fluent temperature unit conversion for .NET 10+** — metric, US customary, and historical scales.

Convert between Celsius, Fahrenheit, Kelvin, Rankine, and even Réaumur or Rømer with a strongly-typed `Temperature` struct — no more guessing which raw `double` means what, and no more hand-rolling the Fahrenheit formula wrong for the tenth time.

> This one, like several of its siblings, came from watching students struggle through their exercises. Temperature conversions look simple until you're the one trying to explain why Fahrenheit needs that strange 459.67 offset, or why Réaumur splits the freezing-to-boiling range into 80 degrees instead of 100. Coding each scale out properly was how I made sure I actually understood what I was about to explain, rather than just repeating a formula from the textbook.
>
> In this case, I wanted each unit conversion to be broken into the same small, obvious steps I'd walk a student through by hand, not buried inside a single formula.

---

## Features

- ✅ **Metric** — Celsius, Kelvin
- ✅ **US customary** — Fahrenheit, Rankine
- ✅ **Historical scales** — Réaumur, Delisle, Newton, Rømer
- ✅ **Strongly typed** — `Temperature` struct instead of a raw `double`, so units can't be mixed up by accident
- ✅ **Fluent API** — `100.DegreesCelsius().ToFahrenheit()`
- ✅ **Comparable & arithmetic** — `-`, `*`, `/`, and full comparison operators (`+` exists but is marked `[Obsolete]` — see below)
- ✅ **Zero dependencies** — pure .NET, no external packages

---

## Installation

```bash
dotnet add package MarcusMedina.Units.Temperature
```

**Requirements:** .NET 10.0+, C# 14.0+

---

## Quick Start

```csharp
using MarcusMedina.Units.Temperature.Metric;
using MarcusMedina.Units.Temperature.US;
using MarcusMedina.Units.Temperature.Historical;

// Create a Temperature from any supported unit
Temperature boiling  = 100.DegreesCelsius();
Temperature freezing = 0.DegreesReaumur();   // 0°Ré = 0°C, same as freezing

// Convert to whatever unit you need
double fahrenheit = boiling.ToFahrenheit();   // 212
double celsius    = freezing.ToCelsius();     // 0

// Arithmetic works directly on Temperature values
Temperature difference = boiling - freezing;  // 100 K (equivalent to a 100°C span)

// Comparisons
bool hotter = boiling > freezing;             // true
```

> **Note on `+`:** adding two *absolute* temperatures together doesn't mean anything physically —
> 100°C + 10°C isn't 110°C. The `+` operator still exists and still compiles, but it's marked
> `[Obsolete]`, so using it produces a compiler warning explaining why. If you're actually modelling
> heat transfer (e.g. a hot coffee cooled by a room-temperature spoon), what you need is a
> mass/heat-capacity-weighted blend, not a raw sum — this struct alone can't do that for you. Use the
> `Kelvin` property directly if you specifically need the raw addition anyway.

---

## API Overview

| Namespace | Unit family |
|-----------|-------------|
| `MarcusMedina.Units.Temperature.Metric` | Celsius, Kelvin |
| `MarcusMedina.Units.Temperature.US` | Fahrenheit, Rankine |
| `MarcusMedina.Units.Temperature.Historical` | Réaumur, Delisle, Newton, Rømer |

Every unit exposes a creation extension (`1.DegreesReaumur()`) and a conversion extension
(`temperature.ToReaumur()`). Unlike the other Units packages, temperature scales aren't
purely multiplicative — each conversion carries its own offset and scale factor — but the
`Temperature` struct still always stores the value in Kelvin internally, so mixing scales
in the same expression is always safe.

---

## Testing

```bash
cd csharp
dotnet test --configuration Release
```

Tests: **21 passed** — covering all unit families, arithmetic operators, and edge cases.

---

## License

MIT — see [LICENSE](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Temperature/blob/main/LICENSE) for details.

---

## Built with Human + AI Collaboration

This library was written by **Marcus Medina** together with **Claude Code** (Anthropic) — not through "vibe coding" where you just describe and accept, but through genuine collaboration: planning together, reviewing each other's decisions, pushing back when something felt wrong, and iterating until the result felt right.

The goal was always to write code worth reading and code worth using — the kind a student can open, understand, and learn from, and the kind any programmer can drop into real, professional work without wanting to rewrite it from scratch. AI was a partner in that process, not a shortcut around it.

If you're curious about this way of working, the source code and git history are open. Every decision has a reason behind it.

## Made for Curious Minds

This library was built with students in mind — not as a black box to copy and paste, but as a real-world example of how clean, purposeful code is written and shared.

Whether you're discovering C# for the first time, need a reliable helper for your school project, or are simply trying to fall in love with writing code — you're exactly who this was made for.

The source is open. Read it, fork it, break it, improve it. That's the whole point.

And if this library saved you an afternoon, or made something click that didn't before — that's everything.

*Non-students are equally welcome. Good code doesn't care about your diploma.*

⭐ If this helped you, consider starring the project on GitHub — it helps other students find it too.

💬 Have an idea, a feature request, or just want to say hi? Open an issue on GitHub — I'd love to hear from you.

## Package Integrity

All releases are signed with [cosign](https://docs.sigstore.dev) (Sigstore keyless signing).

To verify a downloaded package, download both the `.nupkg` and its `.sigstore.json` bundle from the [GitHub Release](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Temperature/releases), then run:

```bash
cosign verify-blob <package.nupkg> \
  --bundle <package.nupkg.sigstore.json> \
  --certificate-identity-regexp "https://github.com/MarcusMedinaPro/.*/release.yml" \
  --certificate-oidc-issuer https://token.actions.githubusercontent.com
```

Expected output: `Verified OK`

## Related Projects

- [MarcusMedina.Units.Area](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Area) — Fluent area unit conversion
- [MarcusMedina.Units.Distance](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Distance) — Fluent distance unit conversion
- [MarcusMedina.Units.Weight](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Weight) — Fluent weight unit conversion
- [MarcusMedina.Units.Math](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Math) — Unit-aware mathematical operations
- [MarcusMedina.Maths.Algebra](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra) — Algebraic expressions and symbolic math
