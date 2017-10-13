var ISDEBUGMODE = false;

$(document).ready(function () {
    showIndicator(true);
    viewModelClients = new EmployesModel();
    
    ko.applyBindings(viewModelClients);
    viewModelClients.getEmployesList();

});

function EmployesModel() {
    var self = this;
    self.employesList = ko.observableArray([]);
    self.currentEmplId = ko.observable('');
    self.ErrorMessage = ko.observable('');
    self.ObEmpl = ko.observable(new EmployeeMod(defEmpl));

    self.getEmployesList = function () {
        $.ajax({
            type: "POST",
            url: '/Home/GetEmployeeList',
            success: function (data) {
                self.currentEmplId('');
                dataEmpl = [];
                self.employesList([]);
               
                for (var i in data) {
                    dataEmpl.push(data[i]);
                }
                ko.utils.arrayPushAll(self.employesList, dataEmpl);
                showIndicator(false);
            },
            error: function (data) {
                showIndicator(false);
                var info = '';
                if (ISDEBUGMODE)
                    info = data.responseText;
                self.ErrorMessage('Error read from server ' + info);
            },
            accept: 'application/json'
        });
    }

    self.selEmpl = function (id) { self.currentEmplId(id); }

    self.readElemEm = function () {
        self.editElem();
    }
    self.editElem = function () {
        var _ob = '';
        self.checkIsElementSelected(self.currentEmplId());
        for (var i in self.employesList()) {
            if (self.employesList()[i].EmployeeId === self.currentEmplId()) {
                _ob = self.employesList()[i];
                self.ObEmpl(new EmployeeMod(_ob));
                break;
            }
        }
    }

    self.checkIsElementSelected = function (id) {
        if (!id) {
            $('#myModal').find('#header').text(self.language.dictionary().attention());
            $('#myModal').find('#content').text("Не вибран елемент");
            $('#myModal').find('#buttonCancel').hide();
            $('#myModal').find('#onClickOk').on('click', function () {
            });
            $('#myModal').modal('show');
        }
        return id;
    }
    self.sexDrop = ko.observableArray([
        new selectedFilter({ id: 'm', name: "муж" }),
        new selectedFilter({ id: 'f', name: "жен" }),
    ]);
    self.depDrop = ko.observableArray();

    self.getDDDepartment = function () {
        $.ajax({
            type: "POST",
            url: "/Home/GetDepartmentsWithDef",
            success: function (data) {
                self.depDrop(data);
            },
            error: function (data) {
                var info = '';
                if (ISDEBUGMODE)
                    info = data.responseText;
                self.ErrorMessage('Error read from server ' + info);
            },
            accept: 'application/json'
        });
    }
    self.getDDDepartment();

    self.saveEmpl = function () {
        data = ko.toJS(self.ObEmpl());
        if (!self.isEmplCorrect(data))
            return;
        showIndicator(true);
        $.ajax({
            type: "POST",
            url: '/Home/SaveEmployee',
            success: function (data) {
                showIndicator(false);
                self.getEmployesList();
            },
            error: function (data) {
                showIndicator(false);
                var info = '';
                if (ISDEBUGMODE)
                    info = data.responseText;
                self.ErrorMessage('Error read from server ' + info);
            },
            data: data,
            accept: 'application/json',
        });
    }
    //TODO Валидация модели
    self.isEmplCorrect = function (data) {
        return true;
    }
}

var defEmpl = {
    EmployeeId: null,
    FullName: '',
    DepartmentId: 1,
    DepartmentName: '',
    Sex: '',
    BDate: DC_DateTimeLocalToStringShortDate(new Date(Date.now())),
    City: '',
    Adress: '',
    Phone: ''   
}

function EmployeeMod(data) {
    self = this;

    self.EmployeeId = ko.observable(data.EmployeeId);
    self.FullName = ko.observable(data.FullName);
    self.DepartmentId = ko.observable(data.DepartmentId);
    self.DepartmentName = ko.observable(data.DepartmentId);
    if (data.BDate === null) {
        self.BDate = ko.observable('');
    }
    else {
       // self.BDate = ko.observable(DC_DateTimeLocalToStringShortDate(DateTimeToInputDateTime(data.BirsdayDate)));
        self.BDate = data.BDateString;
    }
    self.Sex = ko.observable(data.Sex);
    self.City = ko.observable(data.City);
    self.Adress = ko.observable(data.Adress);
    self.Phone = ko.observable(data.Phone);
}

function showIndicator(isShow) {
    if (isShow)
        $('#loadPict').show('slow');
    else
        $('#loadPict').hide('slow');
}

