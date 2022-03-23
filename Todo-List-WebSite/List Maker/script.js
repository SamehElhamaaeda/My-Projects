var theInput = document.querySelector(".add-task input");
var theAddButton = document.querySelector(".add-task .plus");
var tasksContainer = document.querySelector(".tasks-content");
var tasksCount = document.querySelector(".tasks-count span");
var tasksCompleted = document.querySelector(".tasks-completed span");


window.onload = function () {
  theInput.focus();
};


theAddButton.onclick = function () {

  
  if (theInput.value !== ''){

    var noTasksMsg = document.querySelector(".no-tasks-message");

    
    if (document.body.contains(document.querySelector(".no-tasks-message"))) {

      
      noTasksMsg.remove();

    }
    
    var mainSpan = document.createElement("span");
    mainSpan.className = 'task-box';
    
    var deleteElement = document.createElement("span");
    var deleteText = document.createTextNode("Delete");
    deleteElement.appendChild(deleteText);
    deleteElement.className = 'delete';

    var finishElement = document.createElement("span");
    var finishtext = document.createTextNode("Finish");
    finishElement.appendChild(finishtext);
    finishElement.className = 'finish';

    var schedule=document.createElement("input");
    schedule.setAttribute("type","date");
    schedule.setAttribute("class","task-date");

    var text = document.createTextNode(theInput.value);
    mainSpan.appendChild(text);
    
    mainSpan.appendChild(deleteElement);
    mainSpan.appendChild(finishElement);
    mainSpan.appendChild(schedule);
    
    tasksContainer.appendChild(mainSpan);

    
    theInput.value = '';

    
    theInput.focus();

    calculateTasks();

  }

};

document.addEventListener('click', function (e) {

  
  if (e.target.className == 'delete') {

    
    e.target.parentNode.remove();

    
    if (tasksContainer.childElementCount == 0) {

      createNoTasks();

    }

  }


  if (e.target.className=='finish') {

    
    e.target.parentNode.classList.toggle("finished");
    
  }

  
  calculateTasks();

});


function createNoTasks() {


  var msgSpan = document.createElement("span");


  var msgText = document.createTextNode("No Tasks To Show");


  msgSpan.appendChild(msgText);


  msgSpan.className = 'no-tasks-message';


  tasksContainer.appendChild(msgSpan);

}


function calculateTasks() {


  tasksCount.innerHTML = document.querySelectorAll('.tasks-content .task-box').length;


  tasksCompleted.innerHTML = document.querySelectorAll('.tasks-content .finished').length;
}