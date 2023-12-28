# Inventory
Web Api Versioning applied and following nugets used
- Asp.Versioning.Mvc.ApiExplorer
- Swashbuckle.AspNetCore

http header "_x-api-version_" can be set to choose the necessary version of the api
default is setup 

DefaultApiVersion is set to V 2.0  in code
ReportApiVersions is set to ensure the response indicate the supported and deprecated version info

MediaTypeApiVersionReader is allowed and it means content nego is possible ( Accept: text/plain;v=1.0)

Route("api/{version:apiVersion}/[controller]")  if enabled will allow version info via url

VersionGetOperationFilter a custom filter added to swagger to make version non mandatory 
