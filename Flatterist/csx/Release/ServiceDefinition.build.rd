<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Flatterist" generation="1" functional="0" release="0" Id="058d7ea2-e492-45ab-ae77-6ecf39700ee3" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="FlatteristGroup" generation="1" functional="0" release="0">
      <settings>
        <aCS name="Sender:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Flatterist/FlatteristGroup/MapSender:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="SenderInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Flatterist/FlatteristGroup/MapSenderInstances" />
          </maps>
        </aCS>
      </settings>
      <maps>
        <map name="MapSender:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Flatterist/FlatteristGroup/Sender/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapSenderInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Flatterist/FlatteristGroup/SenderInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Sender" generation="1" functional="0" release="0" software="c:\users\wwegner\dropbox\documents\visual studio 2010\Projects\Flatterist.Web\Flatterist\csx\Release\roles\Sender" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Sender&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Sender&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Flatterist/FlatteristGroup/SenderInstances" />
            <sCSPolicyFaultDomainMoniker name="/Flatterist/FlatteristGroup/SenderFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="SenderFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="SenderInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
</serviceModel>