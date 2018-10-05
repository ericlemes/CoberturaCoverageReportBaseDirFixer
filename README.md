# CoberturaCoverageReportBaseDirFixer

Little command line tool to fix filename base dir on Cobertura code coverage report and enable reports generated by OpenCppCoverage to be correctly interpreted by SonarQube c++ Community Plugin.

The idea is specifying a OpenCppCoverage cobertura report, an output file and a base dir. This tool will recursively scan the "filename" attributes and fixes then based on the base dir.

SonarQube should know how to handle them afterwards.


# Usage

```
CoberturaCoverageReportBaseDirFixer <input-report> <output-report> <base-directory>
```

input-report: XML file containing the report
output-report: file name for the processed xml file
base-directory: Base directory to update the report, for example C:\MyProjectRootDirectory


