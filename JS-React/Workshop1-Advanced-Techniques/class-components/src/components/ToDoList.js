import { Component } from 'react';
import ListGroup from 'react-bootstrap/ListGroup';
import ToDoItem from './ToDoItem';

export default class ToDoList extends Component {
    render() {
        console.log(this.props.todos);
        return (
            <ListGroup>
                {this.props.todos.map(todo =>
                    <ToDoItem
                        key={todo.id}
                        onClick={this.props.onToDoClick}
                        onDelete={this.props.onToDoDelete}
                        {...todo}
                    />
                )}

            </ListGroup>
        );
    }
}