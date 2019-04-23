using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IStringLocalizer<ValuesController> _localizer;
        public ValuesController(IStringLocalizer<ValuesController> localizer)
        {
            _localizer = localizer;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("test_lang")]
        public string TestLang()
        {
            return _localizer["Hello"]+' '+_localizer["iFew"];
        }

        [HttpGet("assemblies")]
        public string GetAssemblies()
        {
            StringBuilder result = new StringBuilder();
            result.Append("<h1>Assemblies</h1>");
            foreach(System.Reflection.AssemblyName an in System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies()){                      
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(an.ToString());
                foreach(Type type in asm.GetTypes()){   
                    //PROPERTIES
                    result.Append("<h3>Properties</h3>");
                    foreach (System.Reflection.PropertyInfo property in type.GetProperties()){
                        if (property.CanRead){
                            result.Append("<br>" + an.ToString() + "." + type.ToString() + "." + property.Name);       
                        }
                    }
                    //METHODS
                    result.Append("<h3>Methods</h3>");
                    var methods = type.GetMethods();
                    foreach (System.Reflection.MethodInfo method in methods){               
                        result.Append("<br><b>" + an.ToString() + "."  + type.ToString() + "." + method.Name  + "</b>");   
                        foreach (System.Reflection.ParameterInfo param in method.GetParameters())
                        {
                            result.Append("<br><i>Param=" + param.Name.ToString());
                            result.Append("<br>  Type=" + param.ParameterType.ToString());
                            result.Append("<br>  Position=" + param.Position.ToString());
                            result.Append("<br>  Optional=" + param.IsOptional.ToString() + "</i>");
                        }
                    }
                }
            }

            return result.ToString();
        }

        
    }
}
