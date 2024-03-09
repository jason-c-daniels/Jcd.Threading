# Contributing

When contributing to this repository, please first discuss the change you wish to make via an issue,
email, or any other method deemed appropriate by the owner of this repository before making a change.

Please note there is a [code of conduct](CODE_OF_CONDUCT.md), please follow it in all your interactions
with the project.

## Required Tools

1. ReSharper Ultimate 
   - You will use this to run code coverage, format your code per the editorconfig
   and ReSharper specific settings.
   - You will also use it to detect and resolve warnings through its code inspection feature
   - Before adding suppressions you need the sign-off of the repository owner. 
2. .net8.0-sdk - The latest language features are in use.
3. .Net Framework 4.6.2 - This is so the benchmarks for .Net 4.6.2 can be run.
4. Git.

## Development Process (Broad Strokes)
1. Before you are done you will need to ensure code coverage is as close to 100% as humanly possible
2. You will also resolve  all warnings from ReSharper and the compiler have been resolved or a 
   reason for suppression identified, discussed with the repository owner, and have sign-off.
3. You will also contact the repository owner with the name of your branch so that codefactor.io
   can perform its analysis.
4. You will ensure all issues introduced by your changes are identified by codefactor.io are resolved.

## Pull Request Process

1. The versioning scheme we use is [SemVer](http://semver.org/). The version number is set in AppVeyor. If you
   believe your change warrants a minor version number update, contact the repository owner.
2. You will resolve any issues SonarCloud identifies. If you believe it's a false-positive,
   you will contact the repository owner indicating that and why its the case so that
   it can be flagged as that in SonarCloud. (Right now this only runs at the time of a PR.)
3. You may merge the Pull Request in once you have the sign-off of one other developer, or if you
   do not have permission to do that, you may request the second reviewer to merge it for you.
