import React, { useState } from 'react'
import { Button, TextField } from '@mui/material'
import { Link } from 'react-router-dom'

const Signin = () => {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const handleSubmit = (e) => {
    e.preventDefault()
    console.log('submit', { email, password })
  }
  return (
    <div>
      <h1>Sign In</h1>
      <form className="form" onSubmit={handleSubmit} id="Signin">
        <TextField
          id="email"
          className="signin-input mr-10"
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
          className="signin-input"
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
        <Link to="/signup" color="primary">
          Cadastre-se
        </Link>
      </p>
    </div>
  )
}
export default Signin
