using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCIntro.CommonTools
{

    //Session'i Extension haline getirmemizin nedeni kompleks tiplerimizi de alması gerektigindendir...Extension metotlar sadece generic olmayan static class'larda tanımlanabilir...

    public static class SessionExtension
    {
      
        //Session'imizi olusturabilmek adına / icerisine nesne de atılabilecek bir Session yaratmak adına bir metot yaratıyoruz...

        public static void SetObject(this ISession session,string key,object value)
        {
            string objectString = JsonConvert.SerializeObject(value); //Burada bize gelen object degeri Json formatta bir string'e cevirdik.
            session.SetString(key, objectString);
        }
      
        //Session'u geri almak lazım...Generic metotlar

        public static T GetObject<T>(this ISession session,string key) where T:class//T(T bir referans tip olmak zorundadır
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;

            }
            T deserializedObject = JsonConvert.DeserializeObject<T>(objectString);
            return deserializedObject;
        }

    }
}
