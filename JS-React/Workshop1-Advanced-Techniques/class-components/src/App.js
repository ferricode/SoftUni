
import { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

import ErrorBoundary from './components/ErrorBoundary';

import Header from './components/Header';
import ToDoList from './components/ToDoList';



class App extends Component {
	constructor(props) {
		super(props);

		this.state = {
			todos: [],
			name: 'Ivan V'
		};
	}

	componentDidMount() {

		fetch('http://localhost:3000/data.json')
			.then(res => res.json())
			.then(data => {
				this.setState({
					todos: data.todos,
				});
			});
	}
	onToDoClick(todoId) {
		this.setState({
			todos: this.state.todos.map(todo => todo.id === todoId ? { ...todo, isCompleted: !todo.isCompleted } : todo)
		});
	}
	onToDoDelete(todoId) {
		this.setState({
			todos: this.state.todos.filter(todo => todo.id !== todoId)
		});
	}
	render() {
		return (
			<>
				<ErrorBoundary>
					<Header />
					<h2>{this.state.name}</h2>
					<ToDoList
						todos={this.state.todos}
						onToDoClick={this.onToDoClick.bind(this)}
						onToDoDelete={this.onToDoDelete.bind(this)}
					/>
				</ErrorBoundary>

			</>
		);

	}
}

export default App;
