using System.Collections.Generic;

namespace SupperCRMExample.Models
{
    public class AjaxResponseModel<T>
    {
        public bool Error { get; set; }
        public string Success { get; set; }
        public List<KeyValuePair<string, string>> Errors { get; private set; }
        public T Data { get; set; }

        public void AddError(string key, string message)
        {
            if (Errors == null)
                Errors = new List<KeyValuePair<string, string>>();

            Errors.Add(new KeyValuePair<string, string>(key, message));

            Error = true;
        }
    }
}
