
const { createApp } = Vue;

const app = createApp({
    data() {
        return {
            studentList: [],
            firstName: "",
            lastName: "",
            age: null,
            birthDate: null,
            id: null,
            index: null,
            editMode: false

        }
    },
    mounted: function () {
        console.log("Mouted");
        this.getStudentList();
    },
    methods: {
        getStudentList: function () {
            $.ajax({ url: "/api/student", method: "GET" })
                .done(function (data) {
                    app.studentList = data;
                    console.table(data);
                });

        },
        addStudent: function () {
            var vm = this;
            var newStudent = {
                firstName: vm.firstName,
                lastName: vm.lastName,
                age: vm.age,
                birthDate: vm.birthDate
            }
            $.ajax({
                url: "/api/student",
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(newStudent)
            }).done(function (result) {
                newStudent.id = result;
                vm.studentList.splice(0, 0, newStudent);
                toastr.success("Student added.");

            }).fail(function () {
                toastr.error("Error!");
            }).always(function () {
                vm.firstName = "";
                vm.lastName = "";
                vm.age = null;
                vm.birthDate = null;
            });
        },
        cancelEditStudent: function () {
            const vm = this;
            vm.editMode = false;
            vm.id = null;
            vm.firstName = "";
            vm.lastName = "";
            vm.age = null;
            vm.birthDate = null;
            vm.index = null;
        },
        updateStudent: function () {
            var vm = this;
            const selectedStudent = {
                id: vm.id,
                firstName: vm.firstName,
                lastName: vm.lastName,
                age: vm.age,
                birthDate: vm.birthDate
            };
            $.ajax({
                url: "/api/student",
                method: "PUT",
                contentType: "application/json",
                data: JSON.stringify(selectedStudent)
            }).done(function () {
                vm.studentList[vm.index].firstName = vm.firstName;
                vm.studentList[vm.index].lastName = vm.lastName;
                vm.studentList[vm.index].age = vm.age;
                vm.studentList[vm.index].birthDate = vm.birthDate;
                toastr.success("Student updated.");

            }).fail(function () {
                toastr.error("Error updating Student!");
            }).always(function () {
                vm.editMode = false;
                vm.firstName = "";
                vm.lastName = "";
                vm.age = null;
                vm.birthDate = null;
            });


        },
        editStudent: function (index, selectedStudent) {
            const vm = this;
            vm.editMode = true;
            vm.id = selectedStudent.id;
            vm.firstName = selectedStudent.firstName;
            vm.lastName = selectedStudent.lastName;
            vm.age = selectedStudent.age;
            vm.birthDate = selectedStudent.birthDate;
            vm.index = index;
        },
        removeStudent: function (index, selectedStudent) {
            var vm = this;
            $.ajax({
                url: `/api/student/${selectedStudent.id}`,
                method: "DELETE",
                contentType: "application/json",
            }).done(function () {
                console.log("done");
                vm.studentList.splice(index, 1);
                toastr.success("Student removed.");

            }).fail(function () {
                toastr.error("Error removing Student!");
            });

        }
    }
}).mount('#app');
