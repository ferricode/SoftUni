import { useEffect, useState } from 'react';

import * as userService from './services/userService';

import { Fragment } from 'react';
import { Footer } from './components/Footer';
import { Header } from './components/Header';
import { Search } from './components/Search';
import { UserList } from './components/UserList';
import './App.css';


function App() {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    userService.getAll()
      .then(setUsers)
      .catch(err => {
        console.log('Error' + err);
      });
  }, []);

  const onUserCreateSubmit = async (e) => {
    //1.stop automatic form submit
    e.preventDefault(e);
    //2. Take data from DOM tree
    const formData = new FormData(e.currentTarget);
    const data = Object.fromEntries(formData);
    //3. Send ajax request to server
    const createdUser = await userService.create(data);

    //4. If successfull add new user to the state
    setUsers(state => [...state, createdUser]);

  };
  const onUserUpdateSubmit = async (e, userId) => {
    e.preventDefault();

    const formData = new FormData(e.currentTarget);
    const data = Object.fromEntries(formData);

    const updatedUser = await userService.update(userId, data);

    setUsers(state => state.map(x => x._id === userId ? updatedUser : x));
  };

  const onUserDelete = async (userId) => {
    //Delete from server
    await userService.remove(userId);
    //Delete from state
    setUsers(state => state.filter(x => x._id !== userId));
  };

  return (
    <Fragment>
      <Header />
      <main className="main">
        <section className="card users-container">
          <Search />

          <UserList
            users={users}
            onUserCreateSubmit={onUserCreateSubmit}
            onUserUpdateSubmit={onUserUpdateSubmit}
            onUserDelete={onUserDelete}
          />
        </section>
      </main>
      <Footer />
    </Fragment>
  );
}

export default App;
