import React, { Component, useState } from 'react'
import { Button, Link, TextField } from '@mui/material'

const Login = () => {
  //static displayName = Login.name

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const handleSubmit = (e) => {
    e.preventDefault()
    console.log('submit', { email, password })
  }
  return (
    <div>
      <h1>Login</h1>
      <form className="form" onSubmit={handleSubmit} id="Login">
        <TextField
          id="email"
          className="login-input mr-10"
          label="Email"
          aria-label="Email"
          variant="outlined"
          sx={{ mr: 1 }}
          size="small"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <br />
        <TextField
          id="password"
          className="login-input"
          label="Senha"
          aria-label="Senha"
          variant="outlined"
          sx={{ mr: 1 }}
          size="small"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <br />
        <Button variant="contained" color="secondary" type="submit">
          Entrar
        </Button>
      </form>
      <p>
        Não tem uma conta?{' '}
        <Link href="/subscribe" color="primary">
          Cadastre-se
        </Link>
      </p>
    </div>
  )
}
export default Login
