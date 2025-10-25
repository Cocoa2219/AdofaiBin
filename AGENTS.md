# Repository Guidelines

## Project Structure & Module Organization
- Source lives in `AdofaiBin/` (C#, .NET Framework 4.8.1).
- Serialization pipeline under `AdofaiBin/Serialization/` with `Encoding/`, `Schema/`, `Reflection/`, and `Misc/` subfolders.
- Solution: `AdofaiBin.sln`; NuGet dependencies via `packages.config` restored into `packages/`.

## Build, Restore, and Local Run
- Restore packages: `nuget restore AdofaiBin.sln` (packages.config workflow).
- Build (Debug): `msbuild AdofaiBin.sln /p:Configuration=Debug`
- Build (Release): `msbuild AdofaiBin.sln /p:Configuration=Release`
- Clean: `msbuild AdofaiBin.sln /t:Clean`
- Output goes to `AdofaiBin/bin/<Configuration>/`. This project builds a library/mod; run it via the consuming application or tests.

## Coding Style & Naming Conventions
- Indentation: 4 spaces; encoding: UTF-8; line endings: CRLF.
- Namespaces: `AdofaiBin.*`; one public type per file named after the type.
- PascalCase for classes, methods, properties, events; camelCase for locals/parameters; `_camelCase` acceptable for private readonly fields.
- Prefer immutability, early returns, and expression-bodied members for trivial accessors. Use `var` for obvious types; explicit types for primitives and public APIs.

## Testing Guidelines
- Do not create tests.

## Commit & Pull Request Guidelines
- Ignore prior commit messages; adopt Conventional Commits going forward: `feat:`, `fix:`, `refactor:`, `test:`, `docs:`, `chore:`.
- PRs must include: purpose, short summary, any before/after notes, and linked issues. Keep changes focused and add tests for new behavior.

## Security & Configuration Tips
- Do not commit secrets or local machine paths.
- Keep dependency versions pinned via `packages.config` and audited before upgrades.
- Target framework: `.NETFramework,Version=v4.8.1` — ensure compatible tooling (VS/MSBuild).

