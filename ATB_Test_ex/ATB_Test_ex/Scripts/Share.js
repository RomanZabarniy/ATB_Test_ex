//Проверяет строку на заполненность (учитывает undefined, null и длину строчного представления)
function isStringValueFilled(param) {
    if ('' + param === 'undefined' || '' + param === 'null' || param.toString() === '')
        return false;
    else
        return true;
}

var selectedFilter = function (data) {
    var self = this;
    self.id = ko.observable(data.id);
    self.name = ko.observable(data.name);

};

//------------------------Date converters----------------------------------------------------------------{{{
//Date converter: convert DateTime Local to String Local yyyy-mm-dd
function DC_DateTimeLocalToStringShortDate(data) {
    var date = null;
    if (isStringValueFilled(data)) {
        date = new Date(data);
        var dd = date.getDate();
        var mm = date.getMonth() + 1; //January is 0!

        var yyyy = date.getFullYear();
        if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } date = yyyy + '-' + mm + '-' + dd;
    }

    return date;
}

// converter C# DateTime to yyyy-mm-ddThh:mm
function DateTimeToInputDateTime(data) {
    if (data !== null) {
        date = new Date(parseInt(data.substr(6)));
        dateT = convertUTCDateToLocalDate(new Date(parseInt(data.substr(6))));
        var dd = date.getDate();
        var mm = date.getMonth() + 1; //January is 0!

        var yyyy = date.getFullYear();
        if (yyyy < 1970) yyyy = '0001';
        if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } date = yyyy + '-' + mm + '-' + dd;
        var dt = date + 'T' + ("00" + (dateT.getHours()).toString()).substr(-2, 2) + ":" + ("00" + (dateT.getMinutes()).toString()).substr(-2, 2);
        return dt;
    }
    else
        return "yyyy-mm-dd";

}

//Date converter: convert UTC string 'yyyy-mm-ddThh:mm' to Local string 'yyyy-mm-ddThh:mm'  
function DC_UTCStringToLocalString(data) {
    if (data !== null) {
        date = new Date(data);
        dateT = new Date(data);
        var dd = date.getDate();
        var mm = date.getMonth() + 1; //January is 0!

        var yyyy = date.getFullYear();
        if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } date = yyyy + '-' + mm + '-' + dd;
        var dt = date + 'T' + ("00" + (dateT.getHours()).toString()).substr(-2, 2) + ":" + ("00" + (dateT.getMinutes()).toString()).substr(-2, 2);
        return dt;
    }
    else
        return "yyyy-mm-dd";

}

//Date converter: convert Local string 'yyyy-mm-ddThh:mm' to UTS string 'yyyy-mm-ddThh:mm'  
function DC_localStringToUTCString(data) {
    if (data !== null) {
        //2017-02-09T10:24:00.000Z
        if (data.length === 16) {
            data = data + ':00.000Z';
        }
        date = new Date(data);
        date = new Date(date.getTime() + date.getTimezoneOffset() * 60000 * 2); // умножаем на 2 из-за перообразования Local как UTC
        dateT = date;
        var dd = date.getDate();
        var mm = date.getMonth() + 1; //January is 0!

        var yyyy = date.getFullYear();
        if (yyyy < 1970) yyyy = '0001';
        if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } date = yyyy + '-' + mm + '-' + dd;
        var dt = date + 'T' + ("00" + (dateT.getHours()).toString()).substr(-2, 2) + ":" + ("00" + (dateT.getMinutes()).toString()).substr(-2, 2);
        return dt;
    }
    else
        return "yyyy-mm-dd";

}

//Date converter: convert DateTime Local to yyyy-mm-ddThh:mm
function DC_DateTimeToInputDateTime(data) {
    var date = null;
    if (data !== null) {
        date = new Date(data);
        dateT = new Date(data);
        //dateT = convertDateToUTCDate(date);
        var dd = date.getDate();
        var mm = date.getMonth() + 1; //January is 0!

        var yyyy = date.getFullYear();
        if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } date = yyyy + '-' + mm + '-' + dd;
    }

    var dt = date + 'T' + ("00" + (dateT.getHours()).toString()).substr(-2, 2) + ":" + ("00" + (dateT.getMinutes()).toString()).substr(-2, 2);

    return dt;
}

//Data converter: convert DateTime to Short String Date yyyy-MM-dd
function DC_DateTimeToShortStringData(date) {
    var dateD = [date.getFullYear(), ("00" + (date.getMonth() + 1).toString()).substr(-2, 2), ("00" + date.getDate().toString()).substr(-2, 2)].join("-");//"2016-01-01T01:00"
    return dateD;
}



//----------------------End-Date converters----------------------------------------------------------------}}}