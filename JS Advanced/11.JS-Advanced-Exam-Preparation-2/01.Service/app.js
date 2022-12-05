window.addEventListener("load", solve);

function solve() {
	document
		.querySelector("button[type='submit']")
		.addEventListener("click", createTask);
	document
		.getElementsByClassName("clear-btn")[0]
		.addEventListener("click", clearOrders);
	let productType = document.getElementById("type-product");
	let description = document.getElementById("description");
	let name = document.getElementById("client-name");
	let phone = document.getElementById("client-phone");
	let receivedOrdersSection = document.getElementById("received-orders");
	let complitedOrdersSection = document.getElementById("completed-orders");
	// let clearBtn=complitedOrdersSection.querySelector("button");
	// clearBtn.addEventListener("click", clearOrders)

	function createTask(e) {
		e.preventDefault();

		let productTypeValue = productType.value;
		let descriptionValue = description.value;
		let nameValue = name.value;
		let phoneValue = phone.value;

		if (!descriptionValue || !nameValue || !phoneValue) {
			return;
		}

		createOrder(productTypeValue, descriptionValue, nameValue, phoneValue);
		clearFormFields();
	}
	function createOrder(
		productTypeValue,
		descriptionValue,
		nameValue,
		phoneValue
	) {
		let divContainer = document.createElement("div");
		divContainer.classList.add("container");

		let h2 = document.createElement("h2");
		h2.textContent = `Product type for repair: ${productTypeValue}`;

		let h3 = document.createElement("h3");
		h3.textContent = `Client information: ${nameValue}, ${phoneValue}`;

		let h4 = document.createElement("h4");
		h4.textContent = `Description of the problem: ${descriptionValue}`;

		let startButton = document.createElement("button");
		startButton.classList.add("start-btn");
		startButton.textContent = "Start repair";
		startButton.addEventListener("click", startRepair);

		let finishButton = document.createElement("button");
		finishButton.classList.add("finish-btn");
		finishButton.textContent = "Finish repair";
		finishButton.setAttribute("disabled", true);
		finishButton.addEventListener("click", finishRepair);

		divContainer.appendChild(h2);
		divContainer.appendChild(h3);
		divContainer.appendChild(h4);
		divContainer.appendChild(startButton);
		divContainer.appendChild(finishButton);
		receivedOrdersSection.appendChild(divContainer);
	}

	function startRepair(e) {
		e.target.setAttribute("disabled", true);
		e.target.parentElement.getElementsByClassName(
			"finish-btn"
		)[0].disabled = false;
	}
	function finishRepair(e) {
		let currentOrder = e.target.parentElement;
		complitedOrdersSection.appendChild(currentOrder);
		Array.from(currentOrder.querySelectorAll("button")).forEach((btn) =>
			btn.remove()
		);
	}
	function clearFormFields() {
		description.value = "";
		name.value = "";
		phone.value = "";
	}
	function clearOrders(e) {
		let containers = complitedOrdersSection.querySelectorAll(".container");
		Array.from(containers).forEach((c) => c.remove());
	}
}
