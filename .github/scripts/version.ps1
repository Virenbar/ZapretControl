dotnet tool install --global minver-cli --version 4.2.0
$version = minver -t v -d preview
$number = $version.Split('-')[0]
Write-Output "VERSION=$version"
Write-Output "V=$number"
"VERSION=$version" >> $env:GITHUB_ENV
"V=$number" >> $env:GITHUB_ENV
Write-Output "{version}={$version}" >> $GITHUB_OUTPUT