import { Counter } from './components/Counter'
import { FetchData } from './components/FetchData'
import { Home } from './pages/Home'
import Signup from './pages/Signup'
import Signin from './pages/Signin'
import { SearchResults } from './pages/SearchResults'
import { TeacherDetails } from './pages/Teacher'

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: '/signup',
    element: <Signup />,
  },
  {
    path: '/signin',
    element: <Signin />,
  },
  {
    path: '/counter',
    element: <Counter />,
  },
  {
    path: '/fetch-data',
    element: <FetchData />,
  },
  {
    path: '/results',
    element: <SearchResults />,
  },
  {
    path: '/teacher',
    element: <TeacherDetails />,
  },
]

export default AppRoutes
