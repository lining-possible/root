<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>DCS画面导航</title>
    <!--引入多语言文件-->
    <link href="css/public.css" rel="stylesheet" type="text/css"/>
    <link href="css/mainAlarm.css" rel="stylesheet" type="text/css"/>
    <link href="css/ondutyinfo.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/dcsanywhere.js"></script>
</head>
<body>
<div class="topcont"> </div>

<div class="lefttop" id="lefttop"></div>
<div id="mid" style="height: 570px">
    <div id="mid_l" style="width:15%; height: 100%;">
        <!--  -->
        <!----导航---->
        <ul id="left02">

            <li class="nlst2" id="dcs1">质量</li>
            <li class="nlst2" id="dcs2">设备</li>
            <li class="nlst2" id="dcs3">应急</li>
            <li class="nlst2" id="dcs4">物流</li>
            <li class="nlst2" id="dcs5">MES</li>
            <li class="nlst2" id="dcs6">计划</li>
            <li class="nlst2" id="dcs7">生产</li>

        </ul>
  </div>
    <!-- end left -->
    <!-- right -->
    <div id="mid_r" style="height: 100%;width:82%; position: relative;">    </div>

</div>

</body>
</html>