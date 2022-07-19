using FishNet.Transporting.Bayou;
using FishNet.Transporting.Multipass;
using FishNet.Transporting.Tugboat;
using UnityEngine;

public class TransportSetter : MonoBehaviour
{

    private void Awake()
    {

        Multipass mp = GetComponent<Multipass>();

#if UNITY_WEBGL && !UNITY_SERVER && !UNITY_EDITOR
        mp.SetClientTransport<Bayou>();
#else
        mp.SetClientTransport<Tugboat>();
#endif

        Debug.Log("Client transport set as " + mp.ClientTransport);

    }

}
