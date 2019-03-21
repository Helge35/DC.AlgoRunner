Deploy :

1. ng build --base-href "/AlgoRunner/" --prod

1.1 On error : 

2. Add web.config:
<?xml version="1.0" encoding="utf-8"?>
<configuration>

<system.webServer>
  <rewrite>
    <rules>
      <rule name="Angular Routes" stopProcessing="true">
        <match url=".*" />
        <conditions logicalGrouping="MatchAll">
          <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
          <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
        </conditions>
        <action type="Rewrite" url="./AlgoRunner" />
      </rule>
    </rules>
  </rewrite>
</system.webServer>

</configuration>

ERROR 500.19 Erorr : Your IIS is missing URL Rewrite module.

You can download and install it here from microsoft: https://www.iis.net/downloads/microsoft/url-rewrite

ERROR in ./node_modules/rxjs/ :
Looks like the problem is that your rxjs module corrupted. You can try the following to fix- 1.Try npm cache clean --force if it doesn't work then manually delete %appdata%\npm-cache folder.

Delete your node_modules from project.
Reinstall all you node modules - npm install