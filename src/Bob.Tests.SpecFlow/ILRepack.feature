Feature: ILRepack

	In order to support the community using ILRepack
	I want to be able to use it in the Bob's tasks

	Scenario: Merging all artifacts

  		Given there is bob repository cloned into "D:/Projects/bob" directory
        And "D:/Projects/bob" is the working directory
        And there is bob repository already restored in "D:/Projects/bob/packages" directory
        And there is bob repository already compiled in "D:/Projects/bob/build/output" directory
		When I execute the following task

		| Code                                                                        |
		| ILRepack.Merge(parameters =>                                                |
		| {                                                                           |
		| parameters.Output = FileSystem.Directories.Relative("build/merge/bob.exe"); |
		| parameters.Primary = FileSystem.Files.Match("build/output/bob.exe");        |
		| parameters.Assemblies = FileSystem.Files.Match("build/output/*.dll");       |
		| })                                                                          |

		Then the following process is being executed

		| Parameter        | Value                                                                                                                                                                                                |
		| Process          | D:\Projects\bob\packages\ilrepack.1.26.0\tools\ilrepack.exe                                                                                                                                          |
		| WorkingDirectory | D:\Projects\bob                                                                                                                                                                                      |
		| Arguments        | /out:D:\Projects\bob\build\merge\bob.exe D:\Projects\bob\build\output\Bob.exe D:\Projects\bob\build\output\Microsoft.CodeAnalysis.CSharp.dll D:\Projects\bob\build\output\Microsoft.CodeAnalysis.dll |
