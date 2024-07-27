using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json;

public class RegisterScripts : MonoBehaviour
{
    public TMP_InputField edtUser, edtPass, edtRePass;
    public TMP_Text txtMessage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DangKy()
    {
        StartCoroutine(Register());
        Register();
    }
    IEnumerator Register()
    {
        // lấy giá trị từ InputField

        string user = edtUser.text;
        string pass = edtPass.text;
        string rePass = edtRePass.text;
        txtMessage.text = "";

        if(pass.Equals(rePass))
        {
            UserRegisterModel userRegisterModel = new UserRegisterModel(user, pass);  
            string jsonStringRequest = JsonConvert.SerializeObject(userRegisterModel);

            var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/register", "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                var jsonString = request.downloadHandler.text.ToString();
                MessageModel message = JsonConvert.DeserializeObject<MessageModel>(jsonString);
                txtMessage.text = message.notification;
            }
            request.Dispose();
        }
    
        else
        {
            //hiện thị thông báo
            txtMessage.text = "Mật khẩu không trùng";
        }
        
}
}
