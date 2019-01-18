/* Chinese initialisation for the jQuery UI date picker plugin. */
/* Written by Cloudream (cloudream@gmail.com). */
jQuery(function($){
	
	var lang = $.cookie("FCS-LLCFG") || "zh";
	$.datepicker.regional['zh-CN'] = {};
	if(lang == "zh"){
		$.datepicker.regional['zh-CN'] = {
			closeText: '关闭',
			prevText: '&#x3C;上月',
			nextText: '下月&#x3E;',
			currentText: '今天',
			monthNames: ['一月','二月','三月','四月','五月','六月',
			'七月','八月','九月','十月','十一月','十二月'],
			monthNamesShort: ['一月','二月','三月','四月','五月','六月',
			'七月','八月','九月','十月','十一月','十二月'],
			dayNames: ['星期日','星期一','星期二','星期三','星期四','星期五','星期六'],
			dayNamesShort: ['周日','周一','周二','周三','周四','周五','周六'],
			dayNamesMin: ['日','一','二','三','四','五','六'],
			weekHeader: '周',
			dateFormat: 'yy-mm-dd',
			firstDay: 1,
			isRTL: false,
			showMonthAfterYear: true,
			yearSuffix: '年'
		};
	} else {
		$.datepicker.regional['zh-CN'] = {
			closeText: 'Close',
			prevText: '&#x3C;Before Mon',
			nextText: 'Next Mon&#x3E;',
			currentText: 'Today',
			monthNames: ['Jan','Feb','Mar','Apr','May','Jun',
			'Jul','Aug','Sep','Oct','Nov','Dec'],
			monthNamesShort: ['Jan','Feb','Mar','Apr','May','Jun',
			'Jul','Aug','Sep','Oct','Nov','Dec'],
			dayNames: ['Su','Mo','Tu','We','Th','Fr','Sa'],
			dayNamesShort: ['Su','Mo','Tu','We','Th','Fr','Sa'],
			dayNamesMin: ['Su','Mo','Tu','We','Th','Fr','Sa'],
			weekHeader: 'W',
			dateFormat: 'yy-mm-dd',
			firstDay: 1,
			isRTL: false,
			showMonthAfterYear: true,
			yearSuffix: 'Year'
		};
	}
	$.datepicker.setDefaults($.datepicker.regional['zh-CN']);
});
