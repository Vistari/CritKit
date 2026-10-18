<div align="center">

<pre>
&lt;+~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+&gt;
 |      __        ██████╗██████╗ ██╗████████╗   ██╗  ██╗██╗████████╗ | 
 |    _/  \_     ██╔════╝██╔══██╗██║╚══██╔══╝   ██║ ██╔╝██║╚══██╔══╝ | 
 |   / \  / \    ██║     ██████╔╝██║   ██║      █████╔╝ ██║   ██║    | 
 |  |  \20/  |   ██║     ██╔══██╗██║   ██║      ██╔═██╗ ██║   ██║    | 
 |   \_/  \_/    ╚██████╗██║  ██║██║   ██║      ██║  ██╗██║   ██║    | 
 |     \__/       ╚═════╝╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝  ╚═╝╚═╝   ╚═╝    | 
&lt;+~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+&gt;
</pre>

</div>

<p align="center">-- For when sudo isn't enough magic. --</p>

A Dungeons and Dragons focused CLI. Roll dice, look up spells, explore the rules.

## Getting started

CritKit is built on [System.CommandLine](https://github.com/dotnet/command-line-api) and targets .NET 10.

```
dotnet run --project src/CritKit.CommandLine
```

Running with no arguments shows the splash screen above. Use `--help` to see available commands.

## Commands

### `roll`

Roll dice using standard dice notation.

```
dotnet run --project src/CritKit.CommandLine -- roll 2d20+1d6-3
```

Accepts a single die (`d20`), multiple dice (`2d6`), and simple equations combining dice and modifiers with `+` and `-` (`2d20+1d6-3`).

## Roadmap

CritKit is early and under active development. Planned for future versions:

- **Spells** — look up spells from the core rules by name, level, class, or school.
- **Custom spells** — define and manage your own homebrew spells alongside the core list.
- **Rules** — search and reference core rules text directly from the CLI.
- **Detailed dice roll results** — see each individual die result, modifiers applied, and totals broken down, rather than just the final sum.

## Publishing a native (AOT) build

CritKit can be compiled ahead-of-time into a single native executable with no .NET runtime dependency, using [.NET Native AOT](https://learn.microsoft.com/dotnet/core/deploying/native-aot/).

From the repository root, publish for your target platform's runtime identifier (RID):

```
# Windows x64
dotnet publish src/CritKit.CommandLine -c Release -r win-x64 -p:PublishAot=true --self-contained

# Linux x64
dotnet publish src/CritKit.CommandLine -c Release -r linux-x64 -p:PublishAot=true --self-contained

# macOS (Apple Silicon)
dotnet publish src/CritKit.CommandLine -c Release -r osx-arm64 -p:PublishAot=true --self-contained
```

The resulting native binary is written to `src/CritKit.CommandLine/bin/Release/net10.0/<rid>/publish/` as `critkit` (`critkit.exe` on Windows), and can be run directly without `dotnet run` or an installed .NET runtime, e.g.:

```
./src/CritKit.CommandLine/bin/Release/net10.0/win-x64/publish/critkit.exe roll 1d6
```

> AOT compilation requires platform-specific build tools (e.g. the Visual C++ Build Tools on Windows, `clang` on Linux/macOS). See the [Native AOT prerequisites](https://learn.microsoft.com/dotnet/core/deploying/native-aot/#prerequisites) docs for details.

### Running `critkit` from anywhere

To call the published binary as plain `critkit roll 1d6` from any directory, add its publish folder to your `PATH`.

**Windows (PowerShell):**

```powershell
$publishDir = "$PWD\src\CritKit.CommandLine\bin\Release\net10.0\win-x64\publish"
[Environment]::SetEnvironmentVariable("Path", "$env:Path;$publishDir", "User")
```

Open a new terminal window for the updated `PATH` to take effect, then run:

```powershell
critkit roll 1d6
```

**Linux/macOS (bash/zsh):**

```bash
publish_dir="$(pwd)/src/CritKit.CommandLine/bin/Release/net10.0/linux-x64/publish"
echo "export PATH=\"\$PATH:$publish_dir\"" >> ~/.bashrc   # or ~/.zshrc
source ~/.bashrc

critkit roll 1d6
```

Alternatively, copy or symlink the `critkit`/`critkit.exe` binary into a directory that's already on your `PATH` (e.g. `/usr/local/bin` on Linux/macOS).
