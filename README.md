# scratch-repo

A deliberately tiny .NET solution used to practise the AI platform's isolated worker (Phase 4). It contains a small `TaskList` class and its tests,
nothing else. It must stay free of secrets and of anything you care about: the worker clones it, applies a patch, builds and tests it.

```text
ScratchRepo.slnx
src/Tasks/            TaskList, TaskItem
tests/Tasks.Tests/    xUnit tests
```

Build and test locally (the worker runs the same three commands):

```bash
dotnet restore ScratchRepo.slnx --locked-mode
dotnet build ScratchRepo.slnx --configuration Release --no-restore
dotnet test ScratchRepo.slnx --configuration Release --no-build
```

Every project keeps a committed `packages.lock.json`. After changing a package version run `dotnet restore ScratchRepo.slnx` (without `--locked-mode`) and commit the updated lock files.
