using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RosSharp.RosBridgeClient{

public class contCombinedInfo : UnityPublisher<MessageTypes.CombinedInfo.Info>
{
    public GameObject game;
    private float pretime;
    private MessageTypes.CombinedInfo.Info message;
    private Vector3 patpos=Vector3.zero;
    private Quaternion qn = Quaternion.identity;
    
    protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }
    private void InitializeMessage()
        {
            message = new MessageTypes.CombinedInfo.Info();
            message.accl = new MessageTypes.CombinedInfo.Vector3();
            message.angvel = new MessageTypes.CombinedInfo.Vector3();
            message.rot = new MessageTypes.CombinedInfo.Vector3();
            
        }
    // Update is called once per frame
    void Update()
    {
        Updatemess();
    }
   private void Updatemess(){
float deltatime=Time.realtimeSinceStartup-pretime;
        Vector3 linacc =(game.transform.position-patpos)/(deltatime);
        Vector3 angularvel=(game.transform.rotation.eulerAngles-qn.eulerAngles)/deltatime;
        Vector3 rota=game.transform.rotation.eulerAngles;
        message.accl=GetGeomatry(linacc.Unity2Ros());
        message.angvel=GetGeomatry(angularvel.Unity2Ros());
        message.rot=GetGeomatry(rota.Unity2Ros());
        pretime = Time.realtimeSinceStartup;
        patpos = game.transform.position;
        qn = game.transform.rotation;
        Publish(message); }

   private static MessageTypes.CombinedInfo.Vector3 GetGeomatry(Vector3 vector3)
        {
            MessageTypes.CombinedInfo.Vector3 geometryVector3 = new MessageTypes.CombinedInfo.Vector3();
            geometryVector3.x = vector3.x;
            geometryVector3.y = vector3.y;
            geometryVector3.z = vector3.z;
            return geometryVector3;
        }














}}
