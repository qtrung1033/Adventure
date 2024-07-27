using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LayOTP : MonoBehaviour
{
    public TMP_InputField edtUser, edtOTP, edtMKmoi;
    public TMP_Text txtMessage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sendOTP()
    {
        var user = edtUser.text;
        UserRegisterModel userRegisterModel = new UserRegisterModel(user);
        StartCoroutine(sendOtp(userRegisterModel));
    }
    public void ResetPassword()
    {
        var user = edtUser.text;
        var otp = int.Parse(edtOTP.text);
        var newPass = edtMKmoi.text;
        QuenMkModel quenMkModel = new QuenMkModel(user, otp, newPass);
        StartCoroutine(quenMK(quenMkModel));
    }
    IEnumerator sendOtp(UserRegisterModel userRegisterModel)
    {
        //…
        string jsonStringRequest = JsonConvert.SerializeObject(userRegisterModel);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/send-otp", "POST");
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
    IEnumerator quenMK(QuenMkModel quenMkModel)
    {
        //…
        string jsonStringRequest = JsonConvert.SerializeObject(quenMkModel);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/reset-password", "POST");
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

}
