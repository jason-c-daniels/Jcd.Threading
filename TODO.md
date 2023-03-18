# TODOs
Jason, do these ASAP.

## Before you begin coding

1. If you didn't push to github as part of the project creation, you'll need to do so before setting up the AppVeyor and codefactor.io links
2. Setup the [AppVeyor project](https://ci.appveyor.com/projects) and replace TODO_YOUR_PROJECT_SLUG_HERE, in this file, with the project slug.
* The project slug can be found in the URL of the project after creation or on the Settings/General tab.
* On the Settings/General tab
    - Set your build version (typically to 0.0.{build} for a new project.)
    - Turn on AssemblyInfo patching.
    - Turn on .NET Core project files patching.
* On the Settings/Environment tab, select the Ubuntu build worker image to ensure unit tests run on Linux.
* On the Settings/Build tab
    - Set "Configuration" to "Release"
    - Turn on "Package NuGet projects."
* On the Settings/Deployment tab
    - Set up a NuGet provider pointed to MyGet: https://www.myget.org/F/jason-c-daniels/api/v2/package
    - Set your API key/personal access token. You can get it from your [MyGet Access Tokens](https://www.myget.org/profile/Me#!/AccessTokens)
    - Turn on "Deploy from branch" with the branch set to "main"
3. Setup the [codefactor.io project](https://www.codefactor.io/dashboard).
* Click the "+ Add" button on the [dashboard](https://www.codefactor.io/dashboard)
* Select Jcd.Tasks from the list.
* Click "Import" at the bottom of the screen.
4. Review various generated non-code files to ensure you have customized the content to this project's
   needs. *The list is relative to the repository root directory.*
* [.github/ISSUE_TEMPLATE/bug_report.md](.github/ISSUE_TEMPLATE/bug_report.md)
* [.github/ISSUE_TEMPLATE/feature_request.md](.github/ISSUE_TEMPLATE/feature_request.md)
* [.github/ISSUE_TEMPLATE/technical_task.md](.github/ISSUE_TEMPLATE/technical_task.md)
* [.github/ISSUE_TEMPLATE/user_story.md](.github/ISSUE_TEMPLATE/user_story.md)
* [.github/FUNDING.yml](.github/FUNDING.yml) - Remove this if you don't want to solicit funding for your works. (Currently only has Patreon and Ko-Fi entries)
* [LICENSE](LICENSE)
* [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md)
* [CONTRIBUTING.md](CONTRIBUTING.md)
* [PULL_REQUEST_TEMPLATE.md](PULL_REQUEST_TEMPLATE.md)
5. Delete this section of this file and replace it with something meaningful.

