const inputBox = document.getElementById("input-box");
const listContainer = document.getElementById("list-container");

async function fetchAndAppendTodos() {
  try {
    const response = await fetch(
      "https://976b-20-195-24-72.ngrok-free.app/api/todo"
    );
    const todos = await response.json();

    todos.forEach((todo) => {
      let li = document.createElement("li");
      li.innerHTML = todo.title;
      li.dataset.id = todo.id;
      if (todo.isComplete) {
        li.classList.toggle("checked");
      }
      console.log(todo);
      listContainer.appendChild(li);
      let span = document.createElement("span");
      span.innerHTML = "\u00d7";
      li.appendChild(span);
    });
  } catch (error) {
    console.error("Error fetching todos:", error);
  }
}

async function addTask() {
  if (inputBox.value === "") {
    alert("Enter Something");
  } else {
    const taskTitle = inputBox.value; // Extract the task title from the input box

    try {
      const response = await fetch(
        "https://976b-20-195-24-72.ngrok-free.app/api/todo",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            title: taskTitle,
          }),
        }
      );

      if (!response.ok) {
        alert("failed to add task");
      }

      // If the request is successful, update the UI to display the new task
      const newTask = await response.json();
      let li = document.createElement("li");
      li.innerHTML = newTask.title;
      li.dataset.id = newTask.id;
      li.dataset.title = newTask.title;
      listContainer.appendChild(li);
      let span = document.createElement("span");
      span.innerHTML = "\u00d7";
      li.appendChild(span);
    } catch (error) {
      console.error("Error adding task:", error);
    }
  }
  inputBox.value = "";
}

// updation code
listContainer.addEventListener(
  "click",
  async function (e) {
    if (e.target.tagName === "LI") {
      const todoId = e.target.dataset.id;
      const title = e.target.dataset.title;
      try {
        const response = await fetch(
          `https://976b-20-195-24-72.ngrok-free.app/api/todo/${todoId}`,
          {
            method: "PUT",
            headers: {
              "Content-Type": "application/json",
            },

            body: JSON.stringify({
              id: todoId,
              title: title,
              isComplete: !e.target.classList.contains("checked"),
            }),
          }
        );

        if (!response.ok) {
          alert("Failed to Update Status");
        } else {
          e.target.classList.toggle("checked");
        }
      } catch (error) {
        alert("Failed to Update Status");
      }
    } else if (e.target.tagName === "SPAN") {
      const todoId = e.target.parentElement.dataset.id;
      try {
        const response = await fetch(
          `https://976b-20-195-24-72.ngrok-free.app/api/todo/${todoId}`,
          {
            method: "DELETE",
          }
        );

        if (!response.ok) {
          alert("Failed to Delete Todo");
        }

        // Remove the todo item from the UI
        e.target.parentElement.remove();
      } catch (error) {
        alert("Failed to Delete Todo");
      }
    }
  },
  false
);

window.addEventListener("load", fetchAndAppendTodos);
