import React, { useState } from 'react';
import './App.css';

function App() {
  const [email, setEmail] = useState('libeanonyme@gmail.com')
  const [password, setPassword] = useState('libeanonyme@gmail.com')

  function handleSignUpSubmit(event) {
    event.preventDefault()
  }

  function handleSignInSubmit(event) {
    event.preventDefault()
  }

  return (
    <div className="App">
      <h1>Phenomenom</h1>
      <h2>Sign up</h2>
      <form onSubmit={handleSignUpSubmit}>
        <div>
          <input
            type="email"
            placeholder="Email"
            value={email}
            onChange={event => setEmail(event.target.value)}
          />
        </div>
        <div>
          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={event => setPassword(event.target.value)}
          />
        </div>
        <button type="submit" onClick={handleSignUpSubmit}>
          Sign up
        </button>
      </form>
      <h2>Sign in</h2>
      <form onSubmit={handleSignInSubmit}>
        <div>
          <input
            type="email"
            placeholder="Email"
            value={email}
            onChange={event => setEmail(event.target.value)}
          />
        </div>
        <div>
          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={event => setPassword(event.target.value)}
          />
        </div>
        <button type="submit" onClick={handleSignInSubmit}>
          Sign in
        </button>
      </form>
    </div>
  );
}

export default App;
