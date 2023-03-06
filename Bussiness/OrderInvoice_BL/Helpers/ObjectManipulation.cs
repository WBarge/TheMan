using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Utilites;

namespace OrderInvoice_BL.Helpers
{
    public class ObjectManipulation
    {
        /// <summary>
        /// Copies the properties from one object to another
        /// it only copies properties that match on name and type
        /// </summary>
        /// <typeparam name="TSrc">the type of the source object</typeparam>
        /// <typeparam name="TDest">the type of the destination object</typeparam>
        /// <param name="srcObj">the source object</param>
        /// <param name="destObj">the destination object</param>
        /// <param name="excludePropertyList"></param>
        public static void CopyProperties<TSrc, TDest>(TSrc srcObj, TDest destObj,IEnumerable<string> excludePropertyList=null)
        {
            foreach (PropertyInfo sProp in srcObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                // ReSharper disable once PossibleMultipleEnumeration
                if (excludePropertyList.IsEmpty() || excludePropertyList.Contains(sProp.Name) == false)
                {
                    PropertyInfo dProp = destObj.GetType().GetProperty(sProp.Name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    // ReSharper disable once PossibleNullReferenceException
                    if (dProp.IsNotEmpty() && dProp.GetType() == sProp.GetType())
                    {
                        dProp.SetValue(destObj, sProp.GetValue(srcObj, null), null);
                    }//end of if
                }
            }//end of foreach
        }//end of CopyProperties
    }
}
