Feature: MsBuild

	In order to support the community using MsBuild
	I want to be able to use it in the Bob's tasks

	Scenario: Compiling NetJSON using MsBuild 12.0

		Given a MsBuild version 12.0 is available
		And there is NetJSON repository cloned into "D:/Projects/NetJSON" directory
        And "D:/Projects/NetJSON" is the working directory
		When I execute the following task

		| Code                              |
		| MsBuild.Compile(parameters => {}) |

		Then the following process is being executed

		| Parameter        | Value                                                     |
		| Process          | C:\Program Files (x86)\MSBuild\12.0\bin\amd64\msbuild.exe |
		| WorkingDirectory | D:\Projects\NetJSON                                       |
		| Arguments        |                                                           |

	Scenario: Compiling NetJSON using MsBuild 12.0 into specified directory

		Given a MsBuild version 12.0 is available
		And there is NetJSON repository cloned into "D:/Projects/NetJSON" directory
        And "D:/Projects/NetJSON" is the working directory
		When I execute the following task

		| Code                                                                 |
		| MsBuild.Compile(parameters =>                                        |
		| {                                                                    |
		| parameters.Output = FileSystem.Directories.Relative("build/output"); |
		| })                                                                   |

		Then the following process is being executed

		| Parameter        | Value                                                     |
		| Process          | C:\Program Files (x86)\MSBuild\12.0\bin\amd64\msbuild.exe |
		| WorkingDirectory | D:\Projects\NetJSON                                       |
		| Arguments        | /p:OutDir=D:\Projects\NetJSON\build\output                |
        
    Scenario: Compiling npgsql using MsBuild 12.0 specifying solution name

   		Given a MsBuild version 12.0 is available
		And there is npgsql repository cloned into "D:/Projects/npgsql" directory
        And "D:/Projects/npgsql" is the working directory
		When I execute the following task

		| Code                                                            |
		| MsBuild.Compile(parameters =>                                   |
		| {                                                               |
		| parameters.Solution = FileSystem.Files.Match("Npgsql2013.sln"); |
		| })                                                              |

		Then the following process is being executed

		| Parameter        | Value                                                     |
		| Process          | C:\Program Files (x86)\MSBuild\12.0\bin\amd64\msbuild.exe |
		| WorkingDirectory | D:\Projects\npgsql                                        |
		| Arguments        | D:\Projects\npgsql\Npgsql2013.sln                         |