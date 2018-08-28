1. 程序建立一个 UDP 服务器，实时接收心跳信息
心跳信息示例：{"name":"program1","period":"50000","message":"infoWWWWW"}
name：名称
period：心跳的周期 单位秒
message：预留信息，当失去心跳后给手机号发送短信会将此消息附带上去

2.程序会启动一个timer任务，每隔一定周期执行， 周期长度写在配置文件中
<add key="CheckPeriod" value="10000" /> 默认 10000毫秒及10秒
timer任务会检是否收到新的心跳，若连续3次没有收到心跳则给手机号发送短信
