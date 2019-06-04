UnityInputByTUIO

    本项目支持在Unity中使用TUIO，并且做了TUIO对于UGUI原生支持，TUIO触摸消息可以直接触发UGUI事件。

    杀毒程序如360可能会导致Mono出现GC错误，如出现 Falat error on GC, getThreadContext fail!  
    请关闭杀毒程序，重启Unity重试。


    要实现TUIO对于UGUI原生支持，操作如下:
        1.需要删除场景中EventSytem.
        2.创建空对象，添加MyEventSystem脚本或者UnityInput脚本即可!
    
    再次声明本程序使用996开源协议！
