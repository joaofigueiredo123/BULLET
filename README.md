# BULLET!

A 2D action-platformer built in Unity as a school final project (PAP — *Prova de Aptidão Profissional*). You run through short levels, pick up guns, shoot enemies, collect coins, and spend them on permanent upgrades.

This repository is an archival snapshot of a project from a few years ago. It is shared as-is for portfolio purposes, not as a maintained product.

## Features

- **Three levels** with locked progression (finish a stage with **E** at the exit to unlock the next)
- **Four save slots**, each with a chosen character, player name, and its own progress
- **Weapon pickups** that spawn one of four guns: AK-47, P90, Colt, or Winchester 1873
- **Coins and timed power-ups** (fire rate, movement speed, or damage, ~15 seconds)
- **Permanent upgrades** bought with coins: extra health, damage, speed, and fire rate (up to 4 levels each)
- **Enemies, traps, and spawners** (including zombies)
- **Statistics** tracked per save: coins, kills, deaths, shots, and jumps
- **Local SQLite persistence** (`gameDB.db` created next to the game when you first play)
- **Settings** for menu music on/off and volume; pause with Escape in-level

Menus and some UI copy are in Portuguese.

## Controls

| Action | Input |
| --- | --- |
| Move | A / D |
| Jump | Space (or the Jump axis) |
| Shoot | Left mouse button (hold) |
| Reload | R |
| Pause / close settings | Escape |
| Finish level | E (at the exit) |

## Tech stack

- **Engine:** Unity **2021.3.18f1** (LTS)
- **Language:** C#
- **2D:** Unity 2D feature set, tilemaps, Rigidbody2D
- **UI:** uGUI + TextMesh Pro
- **Tweening:** [DOTween](http://dotween.demigiant.com/)
- **Saves:** SQLite (`Mono.Data.Sqlite`), local file `gameDB.db`

Gameplay scripts live under `BULLET!/Assets/Scripts/`.

## How to play the game
### Option 1 - Running the .exe
1. Run BULLET!/Executável/BULLET!.exe

### Option 2 - Opening the project on Unity Hub
1. Install **Unity Hub** and **Unity 2021.3.18f1**.
2. Add the `BULLET!` folder as a project and open it.
3. Open `Assets/Scenes/MainMenu.unity` and press Play.

On first launch, the game creates `gameDB.db` in the working directory (typically the project root when playing from the Editor).

## Repository layout

```
PAP/
└── BULLET!/                 Unity project
    ├── Assets/
    │   ├── Scripts/         Gameplay, UI, SQLite, upgrades
    │   ├── Scenes/          Menus + Level 1–3
    │   ├── Prefabs/
    │   └── …                Art, audio, plugins
    ├── Packages/
    ├── ProjectSettings/
    └── Executável/          Leftover Windows player files
```

## Third-party assets and licenses

Several packs and plugins are bundled. If you reuse this project, keep their licenses.

- **Forest Gunner** art pack — [RockyMullet](https://rockymullet.itch.io/forest-gunner-artpack), [CC BY 4.0](https://creativecommons.org/licenses/by/4.0/)
- **DOTween** — Demigiant
- **TextMesh Pro** — Unity (Liberation Sans, OFL)
- **Space Mission** font — freeware, non-commercial ([FontSpace](https://www.fontspace.com/space-mission-font-f56190))
- Additional temporary sprites under `Assets/Temporary/` (weapons, zombie, sci-fi pistol pack)

This project was built for school, not commercial release. Check each asset’s terms before any other use.

## Status

Unmaintained student project. Expect rough edges, placeholder names in the database (character classes), and art still sitting in a `Temporary` folder. That is part of the original snapshot.
