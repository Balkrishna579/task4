#! /usr/bin/env python 

import rospy
from CombinedInfo.msg import Info
from CombinedInfo.msg import Vector3


 
def callback(data):
    print"Linear acc is %s, %s,%s"%(data.accl.x,data.accl.y,data.accl.z)
    print"Angular vel is %s,%s,%s"%(data.angvel.x,data.angvel.y,data.angvel.z)
    print"Rotation is %s,%s,%s"%(data.rot.x,data.rot.y,data.rot.z)
    
def squre():
    rospy.init_node('Information',anonymous=True)
    rospy.Subscriber("ContinousCombinedInfo",Info,callback)
    print"Subscribing"

    rospy.spin()

    
if __name__=='__main__':
    squre()

