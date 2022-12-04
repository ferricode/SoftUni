function solve() {
	document
		.getElementsByTagName("form")[0]
		.addEventListener("submit", createTask);
	let sections = Array.from(document.getElementsByTagName("section"));
	let openSection = sections[1];
	let inProgress = sections[2];
	let complete = sections[3];

	function createTask(e) {
		e.preventDefault();
		let form = e.target;
		let title = form.elements[0].value;
		let desc = form.elements[1].value;
		let date = form.elements[2].value;
		if (title.length === 0 || desc.length === 0 || date.length === 0) {
			return;
		}
		let newArticle = createPartialArticle(
			title,
			desc,
			date,
			{ class: "green", text: "Start" },
			{ class: "red", text: "Delete" }
		);
		openSection.children[1].appendChild(newArticle);
	}
	function createPartialArticle(
		title,
		desc,
		date,
		firstButtoninfo,
		secButtoninfo
	) {
		let buttons = createPartialButton(firstButtoninfo, secButtoninfo);
		let article = document.createElement("article");

		let innerHtml =
			`<h3>${title}</h3>` +
			`<p>Description: ${desc}</p>` +
			`<p>Due Date: ${date}</p>` +
			buttons;
		article.innerHTML = innerHtml;
		article.addEventListener("click", despatchHandler);
		return article;
	}
	function createPartialButton(firstButtoninfo, secButtoninfo) {
		let buttons =
			`<div class="flex">` +
			`<button class="${firstButtoninfo.class}">${firstButtoninfo.text}</button>` +
			`<button class="${secButtoninfo.class}">${secButtoninfo.text}</button>` +
			`</div>`;
		return buttons;
	}
	function despatchHandler(e) {
		if (e.target.tagName !== "BUTTON") {
			return;
		}
		let cmdObj = cmd();
		let text = e.target.innerText.toLowerCase();

		cmdObj[text](e);
	}
	function cmd() {
		return {
			start: function (e) {
				inProgress.children[1].appendChild(e.currentTarget);
				e.target.parentElement.remove();
				e.currentTarget.innerHTML += createPartialButton(
					{ class: "red", text: "Delete" },
					{ class: "orange", text: "Finish" }
				);
			},
			delete: function (e) {
				e.currentTarget.remove();
			},
			finish: function (e) {
				complete.children[1].appendChild(e.currentTarget);
				e.target.parentElement.remove();
			},
		};
	}
}
